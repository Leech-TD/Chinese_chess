<?php


namespace app\admin\controller;


class Buying extends Base
{
    public function index()
    {
        if (request()->isAjax()) {
            $get = $this->request->get();
            $limit = $get['limit'] ?? 10;
            $list = db('order')
                ->join('goods','order.goods_id=goods.goods_id','left')
                ->where('uid0', session('user_id'))
                ->paginate($limit)
                ->toArray();
            return $this->showList($list);
        } else {
            return view();
        }
    }

    public function bookForm()
    {
        if (request()->isPost()) {
            $data = input('post.');
            if ($data['order_id'] == null) {
                db('order')->insert($data);
                return $this->success('订单添加成功！');
            } else {
                db('book')->update($data);
                return $this->success('订单编辑成功！');
            }
        } else {
            $list = db('order_type')->select();
            $this->assign('list', $list);
            return view('book_form');
        }
    }

    public function orderDel()
    {
        $id=input('post.order_id');
        db('order')->delete($id);
        return $this->success('删除成功！');
    }

    public function type()
    {
        return view();
    }
    public function typeData()
    {
        $list = db('book_type')->select();
        return $this->showAll($list);
    }

}