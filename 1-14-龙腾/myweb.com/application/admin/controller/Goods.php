<?php


namespace app\admin\controller;


class Goods extends Base
{
    public function index()
    {
        if (request()->isAjax()) {
            $get = $this->request->get();
            $limit = $get['limit'] ?? 10;
            $key = $get['key'] ?? '';
            $type_id = $get['type'] ?? 0;

            $where = '';
            if ($key) {
                $where .= " and (user_id like '%" . $key . "%'";
                $where .= " or goods_name like '%" . $key . "%')";
            }
          if ($type_id > 0) {
                $where .= " and (r.type_id=" . $type_id . ")";
            }

            $list = db('goods')->alias('u')
                ->join('goods_type r', 'u.type_id = r.type_id', 'left')

               // ->join('sys_user s', 'u.user_id = s.user_id', 'left')

                ->field('u.*,r.type_name')//查询结果
                ->where($where)
              //  ->order('role_id,u.user_id')
                ->paginate($limit)
                ->toArray();
            return $this->showList($list);
        } else {
           $list = db('goods_type')->select();
           $this->assign('list', $list);
            return view();
        }

    }
    public function goodsDel()
    {
        //参数后加/a是因为前面批量删除时会传来数组，如[1,2]
        db('goods')->delete(input('post.goods_id/a'));
        return $this->success('删除成功!');
    }

    public function goodsForm()
    {
        if (request()->isPost()) {
            $data = input('post.');
            if ($data['goods_id'] == null) {
                db('goods')->insert($data);
                return $this->success('商品添加成功！');
            } else {
                db('goods')->update($data);
                return $this->success('商品编辑成功！');
            }
        } else {
            $list = db('goods_type')->select();
            $this->assign('list', $list);
            return view('goods_form');
        }
    }


}